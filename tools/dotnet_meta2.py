import struct

with open("meta_blob.bin","rb") as f:
    meta = f.read()

streams = {'#~': (108, 1347176), '#Strings': (1347284, 441488), '#US': (1788772, 186448), '#GUID': (1975220, 16), '#Blob': (1975236, 297904)}

tilde_off, tilde_size = streams['#~']
strings_off = streams['#Strings'][0]
blob_off = streams['#Blob'][0]

t = meta[tilde_off:tilde_off+tilde_size]
reserved, major, minor, heapsizes, reserved2, valid, sorted_ = struct.unpack_from("<IBBBBQQ", t, 0)
pos = 24

table_names = {
 0x00:'Module',0x01:'TypeRef',0x02:'TypeDef',0x04:'Field',0x06:'MethodDef',
 0x08:'Param',0x09:'InterfaceImpl',0x0A:'MemberRef',0x0B:'Constant',
 0x0C:'CustomAttribute',0x0D:'FieldMarshal',0x0E:'DeclSecurity',
 0x0F:'ClassLayout',0x10:'FieldLayout',0x11:'StandAloneSig',
 0x12:'EventMap',0x14:'Event',0x15:'PropertyMap',0x17:'Property',
 0x18:'MethodSemantics',0x19:'MethodImpl',0x1A:'ModuleRef',0x1B:'TypeSpec',
 0x1C:'ImplMap',0x1D:'FieldRVA',0x20:'Assembly',0x23:'AssemblyRef',
 0x26:'File',0x27:'ExportedType',0x28:'ManifestResource',0x29:'NestedClass',
 0x2A:'GenericParam',0x2B:'MethodSpec',0x2C:'GenericParamConstraint',
}

row_counts = {}
for i in range(64):
    if valid & (1 << i):
        cnt = struct.unpack_from("<I", t, pos)[0]
        pos += 4
        row_counts[i] = cnt

print("Tables present:", {table_names.get(k,hex(k)): v for k,v in row_counts.items()})

str_idx_size = 4 if (heapsizes & 0x01) else 2
guid_idx_size = 4 if (heapsizes & 0x02) else 2
blob_idx_size = 4 if (heapsizes & 0x04) else 2

def simple_idx_size(table):
    return 4 if row_counts.get(table,0) >= 65536 else 2

def coded_idx_size(tables, tagbits):
    maxrows = max(row_counts.get(tb,0) for tb in tables)
    return 4 if maxrows >= (1 << (16-tagbits)) else 2

# coded index definitions (tag bits, [tables...])
TypeDefOrRef = (2, [0x02,0x01,0x1B])  # TypeDef, TypeRef, TypeSpec
HasConstant = (2, [0x04,0x08,0x17])
HasCustomAttribute = (5, list(range(0,0x2D)))  # approx, not used precisely
HasFieldMarshal=(1,[0x04,0x08])
HasDeclSecurity=(2,[0x02,0x06,0x20])
MemberRefParent=(3,[0x02,0x01,0x1A,0x06,0x1B])
HasSemantics=(1,[0x14,0x17])
MethodDefOrRef=(1,[0x06,0x0A])
MemberForwarded=(1,[0x04,0x06])
Implementation=(2,[0x26,0x23,0x27])
CustomAttributeType=(3,[0x06,0x0A,0x00,0x00,0x00])
ResolutionScope=(2,[0x00,0x01,0x1A,0x23])
TypeOrMethodDef=(1,[0x02,0x06])

c_TypeDefOrRef = coded_idx_size(TypeDefOrRef[1], TypeDefOrRef[0])
c_ResolutionScope = coded_idx_size(ResolutionScope[1], ResolutionScope[0])
c_HasConstant = coded_idx_size(HasConstant[1], HasConstant[0])
c_HasFieldMarshal = coded_idx_size(HasFieldMarshal[1], HasFieldMarshal[0])
c_HasDeclSecurity = coded_idx_size(HasDeclSecurity[1], HasDeclSecurity[0])
c_MemberRefParent = coded_idx_size(MemberRefParent[1], MemberRefParent[0])
c_HasSemantics = coded_idx_size(HasSemantics[1], HasSemantics[0])
c_MethodDefOrRef = coded_idx_size(MethodDefOrRef[1], MethodDefOrRef[0])
c_MemberForwarded = coded_idx_size(MemberForwarded[1], MemberForwarded[0])
c_Implementation = coded_idx_size(Implementation[1], Implementation[0])
c_TypeOrMethodDef = coded_idx_size(TypeOrMethodDef[1], TypeOrMethodDef[0])
# HasCustomAttribute has 5 tag bits over many tables -> assume 4 bytes (almost always large)
c_HasCustomAttribute = 4
c_CustomAttributeType = coded_idx_size([0x06,0x0A], 3)

field_idx = simple_idx_size(0x04)
method_idx = simple_idx_size(0x06)
param_idx = simple_idx_size(0x08)
event_idx = simple_idx_size(0x14)
property_idx = simple_idx_size(0x17)

# Define column layouts for tables we need (and ones we must skip over: Module, TypeRef before TypeDef)
def cols_module():
    return [('Generation',2),('Name',str_idx_size),('Mvid',guid_idx_size),('EncId',guid_idx_size),('EncBaseId',guid_idx_size)]

def cols_typeref():
    return [('ResolutionScope',c_ResolutionScope),('Name',str_idx_size),('Namespace',str_idx_size)]

def cols_typedef():
    return [('Flags',4),('Name',str_idx_size),('Namespace',str_idx_size),('Extends',c_TypeDefOrRef),('FieldList',field_idx),('MethodList',method_idx)]

def cols_field():
    return [('Flags',2),('Name',str_idx_size),('Signature',blob_idx_size)]

def cols_methoddef():
    return [('Rva',4),('ImplFlags',2),('Flags',2),('Name',str_idx_size),('Signature',blob_idx_size),('ParamList',param_idx)]

def cols_param():
    return [('Flags',2),('Sequence',2),('Name',str_idx_size)]

def cols_fieldrva():
    return [('Rva',4),('Field',field_idx)]

def read_rows(t, pos, count, cols):
    rows = []
    for i in range(count):
        row = {}
        for name, size in cols:
            if size==2:
                val = struct.unpack_from("<H", t, pos)[0]
            elif size==4:
                val = struct.unpack_from("<I", t, pos)[0]
            else:
                raise Exception("bad size")
            row[name]=val
            pos+=size
        rows.append(row)
    return pos, rows

# We must walk tables in order 0..0x2C, parsing all that exist (at least computing sizes) up to FieldRVA (0x1D)
table_order = sorted(row_counts.keys())
def cols_interfaceimpl():
    return [('Class',simple_idx_size(0x02)),('Interface',c_TypeDefOrRef)]

def cols_memberref():
    return [('Class',c_MemberRefParent),('Name',str_idx_size),('Signature',blob_idx_size)]

def cols_constant():
    return [('Type',2),('Parent',c_HasConstant),('Value',blob_idx_size)]

def cols_customattribute():
    return [('Parent',c_HasCustomAttribute),('Type',c_CustomAttributeType),('Value',blob_idx_size)]

def cols_classlayout():
    return [('PackingSize',2),('ClassSize',4),('Parent',simple_idx_size(0x02))]

def cols_standalonesig():
    return [('Signature',blob_idx_size)]

def cols_eventmap():
    return [('Parent',simple_idx_size(0x02)),('EventList',event_idx)]

def cols_event():
    return [('EventFlags',2),('Name',str_idx_size),('EventType',c_TypeDefOrRef)]

def cols_propertymap():
    return [('Parent',simple_idx_size(0x02)),('PropertyList',property_idx)]

def cols_property():
    return [('Flags',2),('Name',str_idx_size),('Type',blob_idx_size)]

def cols_methodsemantics():
    return [('Semantics',2),('Method',method_idx),('Association',c_HasSemantics)]

def cols_methodimpl():
    return [('Class',simple_idx_size(0x02)),('MethodBody',c_MethodDefOrRef),('MethodDeclaration',c_MethodDefOrRef)]

def cols_typespec():
    return [('Signature',blob_idx_size)]

def cols_assembly():
    return [('HashAlgId',4),('MajorVersion',2),('MinorVersion',2),('BuildNumber',2),('RevisionNumber',2),('Flags',4),('PublicKey',blob_idx_size),('Name',str_idx_size),('Culture',str_idx_size)]

def cols_assemblyref():
    return [('MajorVersion',2),('MinorVersion',2),('BuildNumber',2),('RevisionNumber',2),('Flags',4),('PublicKeyOrToken',blob_idx_size),('Name',str_idx_size),('Culture',str_idx_size),('HashValue',blob_idx_size)]

def cols_manifestresource():
    return [('Offset',4),('Flags',4),('Name',str_idx_size),('Implementation',c_Implementation)]

def cols_nestedclass():
    return [('NestedClass',simple_idx_size(0x02)),('EnclosingClass',simple_idx_size(0x02))]

def cols_genericparam():
    return [('Number',2),('Flags',2),('Owner',c_TypeOrMethodDef),('Name',str_idx_size)]

def cols_methodspec():
    return [('Method',c_MethodDefOrRef),('Instantiation',blob_idx_size)]

def cols_genericparamconstraint():
    return [('Owner',simple_idx_size(0x2A)),('Constraint',c_TypeDefOrRef)]

col_funcs = {
 0x00: cols_module, 0x01: cols_typeref, 0x02: cols_typedef, 0x04: cols_field,
 0x06: cols_methoddef, 0x08: cols_param, 0x09: cols_interfaceimpl,
 0x0A: cols_memberref, 0x0B: cols_constant, 0x0C: cols_customattribute,
 0x0F: cols_classlayout, 0x11: cols_standalonesig, 0x12: cols_eventmap,
 0x14: cols_event, 0x15: cols_propertymap, 0x17: cols_property,
 0x18: cols_methodsemantics, 0x19: cols_methodimpl, 0x1B: cols_typespec,
 0x1D: cols_fieldrva, 0x20: cols_assembly, 0x23: cols_assemblyref,
 0x28: cols_manifestresource, 0x29: cols_nestedclass, 0x2A: cols_genericparam,
 0x2B: cols_methodspec, 0x2C: cols_genericparamconstraint,
}

results = {}
for tbl in table_order:
    cnt = row_counts[tbl]
    if tbl in col_funcs:
        pos, rows = read_rows(t, pos, cnt, col_funcs[tbl]())
        results[tbl] = rows
    else:
        # need a generic skip - must know col sizes; use a best-effort table for common others
        raise Exception(f"Unhandled table {hex(tbl)} with {cnt} rows - need column def")

def get_string(idx):
    end = meta[strings_off+idx:].index(b'\x00')
    return meta[strings_off+idx:strings_off+idx+end].decode('utf-8')

# print TypeDef names
for i,row in enumerate(results.get(0x02,[])):
    name = get_string(row['Name'])
    ns = get_string(row['Namespace'])
    if 'TypeEffectiveness' in name or 'PrivateImplementationDetails' in name or 'BalanceConfig' in name:
        print(i, ns, name, row)

print("--- TypeEffectivenessService methods ---")
method_rows = results[0x06]
for i in range(6168-1, 6390-1):
    m = method_rows[i]
    name = get_string(m['Name'])
    if name == '.cctor':
        print(i+1, name, hex(m['Rva']))
        cctor_rva = m['Rva']

print("--- FieldRVA rows ---")
def blob_size(idx):
    # blob heap: first byte(s) encode length
    b = blob_off+idx
    first = meta[b]
    if first & 0x80 == 0:
        length = first
        hdr=1
    elif first & 0xC0 == 0x80:
        length = ((first & 0x3F)<<8) | meta[b+1]
        hdr=2
    else:
        length = ((first&0x1F)<<24)|(meta[b+1]<<16)|(meta[b+2]<<8)|meta[b+3]
        hdr=4
    return b+hdr, length

field_rows = results[0x04]
for r in results[0x1D]:
    fld = field_rows[r['Field']-1]
    name = get_string(fld['Name'])
    sigoff, siglen = blob_size(fld['Signature'])
    print(hex(r['Rva']), r['Field'], name, "sig_len="+str(siglen), meta[sigoff:sigoff+siglen].hex())

