import pefile, struct, sys

path = r"C:\Users\micha\Desktop\pocketSummonerAlpha\dotnet_dlls\SpiritSummoner_payload.dll"
pe = pefile.PE(path, fast_load=True)
pe.parse_data_directories()

com_dir = pe.OPTIONAL_HEADER.DATA_DIRECTORY[14]
print("CLI header RVA", hex(com_dir.VirtualAddress), "size", com_dir.Size)

cli = pe.get_data(com_dir.VirtualAddress, com_dir.Size)
cb, major, minor, meta_rva, meta_size, flags, entry = struct.unpack_from("<IHHIIII", cli, 0)
print("metadata RVA", hex(meta_rva), "size", meta_size)

meta = pe.get_data(meta_rva, meta_size)
sig, maj, min_, res, verlen = struct.unpack_from("<IHHII", meta, 0)
print("sig", hex(sig), "verlen", verlen)
ver_str = meta[16: 16+verlen]
print("version", ver_str)

pos = 16 + verlen
flags2, nstreams = struct.unpack_from("<HH", meta, pos)
pos += 4
streams = {}
for i in range(nstreams):
    offset, size = struct.unpack_from("<II", meta, pos)
    pos += 8
    name_start = pos
    end = meta.index(b'\x00', name_start)
    name = meta[name_start:end].decode()
    pos = end + 1
    pos = (pos + 3) & ~3
    streams[name] = (offset, size)

print(streams)

with open("meta_blob.bin", "wb") as f:
    f.write(meta)
