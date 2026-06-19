import pefile, struct
pe = pefile.PE(r"C:\Users\micha\Desktop\pocketSummonerAlpha\dotnet_dlls\SpiritSummoner_payload.dll", fast_load=True)
pe.parse_data_directories()

rvas = [0x4d27f0,0x4d2850,0x4d28a8,0x4d2908,0x4d2960,0x4d29b8,0x4d2a18,0x4d2a70,0x4d2ad0,0x4d2b28,0x4d2b80,0x4d2be0,0x4d2c40,0x4d2ca0,0x4d2d08,0x4d2d60,0x4d2db8,0x4d2e18,0x4d2e70,0x4d2ec8,0x4d2f28,0x4d2f80]
sizes = [4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4]

for rva in rvas:
    data = pe.get_data(rva, 96)
    vals = struct.unpack_from("<12d", data, 0)
    print(hex(rva), [round(v,2) for v in vals])
