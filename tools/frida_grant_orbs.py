import sys
import frida

ACTION = sys.argv[1] if len(sys.argv) > 1 else "plan"

def on_message(message, data):
    print("[message]", message)

device = frida.get_usb_device(timeout=10)
session = device.attach("SpiritSummoner")

with open(r"C:\Users\micha\Desktop\pocketSummonerAlpha\tools\frida_grant_orbs.js", "r", encoding="utf-8") as f:
    src = f.read()

script = session.create_script(src)
script.on("message", on_message)
script.load()

result = script.exports_sync.plan()
print("plan:", result)

if ACTION == "grant":
    granted = script.exports_sync.grant()
    print("granted:", granted)

session.detach()
