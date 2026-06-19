import sys
import time
import frida

ACTION = sys.argv[1] if len(sys.argv) > 1 else "status"

def on_message(message, data):
    print("[message]", message)

device = frida.get_usb_device(timeout=10)
session = device.attach("SpiritSummoner")

with open(r"C:\Users\micha\Desktop\pocketSummonerAlpha\tools\frida_energy.js", "r", encoding="utf-8") as f:
    src = f.read()

script = session.create_script(src)
script.on("message", on_message)
script.load()

print("Waiting for hook to capture player instance...")
for i in range(20):
    status = script.exports_sync.status()
    if "error" not in status:
        print("status:", status)
        break
    print("...", status)
    time.sleep(1)
else:
    print("Timed out waiting for player instance. Try opening a screen that shows EP/SP in-game.")
    sys.exit(1)

if ACTION == "refill":
    print("refill result:", script.exports_sync.refill())
    print("status after:", script.exports_sync.status())
elif ACTION == "autorefill_on":
    print(script.exports_sync.autorefill(True))
    print("Press Ctrl+C to stop and detach.")
    while True:
        time.sleep(1)
elif ACTION == "status":
    pass

session.detach()
