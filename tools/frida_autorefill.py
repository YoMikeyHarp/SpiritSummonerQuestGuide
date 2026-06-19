import time
import frida

CHECK_INTERVAL_SECONDS = 10

with open(r"C:\Users\micha\Desktop\pocketSummonerAlpha\tools\frida_energy4.js", "r", encoding="utf-8") as f:
    SRC = f.read()

print(f"EP auto-refill monitor started (refills every {CHECK_INTERVAL_SECONDS}s). Ctrl+C to stop.")

while True:
    try:
        device = frida.get_usb_device(timeout=10)
        session = device.attach("SpiritSummoner")
        script = session.create_script(SRC)
        script.load()

        result = script.exports_sync.refill()
        print("refilled:", result)

        session.detach()
    except Exception as e:
        print("error:", e)

    time.sleep(CHECK_INTERVAL_SECONDS)
