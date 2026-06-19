import pefile, struct
pe = pefile.PE(r"C:\Users\micha\Desktop\pocketSummonerAlpha\dotnet_dlls\SpiritSummoner_payload.dll", fast_load=True)
pe.parse_data_directories()

rva = 0x5d7b4
hdr = pe.get_data(rva, 12)
first = hdr[0]
print("first byte", hex(first))
if (first & 0x3) == 0x2:
    # tiny
    code_size = first >> 2
    code_off = 1
elif (first & 0x3) == 0x3:
    flags, size = struct.unpack_from("<HH", hdr, 0)[0], hdr[2]
    flags = struct.unpack_from("<H", hdr,0)[0]
    headersize = (flags >> 12) & 0xF
    maxstack = struct.unpack_from("<H", hdr,2)[0]
    code_size = struct.unpack_from("<I", hdr,4)[0]
    code_off = headersize*4
    print("fat header, codesize", code_size, "headersize", headersize)
else:
    raise Exception("unknown")

code = pe.get_data(rva + code_off, code_size)
print("code size", len(code))

# scan for ldtoken (0xD0) followed by 4-byte token
i = 0
results = []
while i < len(code):
    op = code[i]
    if op == 0xD0:
        token = struct.unpack_from("<I", code, i+1)[0]
        results.append((i, hex(token)))
        i += 5
    else:
        i += 1

for r in results:
    print(r)
