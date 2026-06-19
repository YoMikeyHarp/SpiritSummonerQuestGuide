import frida, json

with open(r"C:\Users\micha\Desktop\pocketSummonerAlpha\tools\frida_grant_all.js", encoding="utf-8") as f:
    SRC = f.read()

device = frida.get_usb_device(timeout=10)
session = device.attach("SpiritSummoner")
script = session.create_script(SRC)
script.on("message", lambda m, d: print("[msg]", m))
script.load()

# Exclude Mooman (baseSpiritId 99)
result = script.exports_sync.grant_all([99])

print("\n=== SPIRITS ADDED TO COLLECTION ===")
for s in result.get("spiritsAdded", []):
    print(" +", s)

print("\n=== EVOLUTION ORBS GRANTED ===")
for o in result.get("orbsGranted", []):
    print(" +", o)

print("\n=== SKIPPED ===")
for s in result.get("skipped", []):
    print(" -", s)

print("\nDone. Spirits added:", len(result.get("spiritsAdded", [])),
      "| Orbs granted:", len(result.get("orbsGranted", [])))
session.detach()
