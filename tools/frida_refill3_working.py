import sys
import frida

ACTION = sys.argv[1] if len(sys.argv) > 1 else "status"

def on_message(message, data):
    print("[message]", message)

device = frida.get_usb_device(timeout=10)
session = device.attach("SpiritSummoner")

with open(r"C:\Users\micha\Desktop\pocketSummonerAlpha\tools\frida_energy3.js", "r", encoding="utf-8") as f:
    src = f.read()

script = session.create_script(src)
script.on("message", on_message)
script.load()

print("status:", script.exports_sync.status())

if ACTION == "refill":
    print("refill result:", script.exports_sync.refill())
    print("status after:", script.exports_sync.status())

session.detach()
