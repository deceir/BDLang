# BDO English Language Auto-Updater

Automates restoration of the English language file for **Black Desert Online (non-English servers)** after weekly patches.

## What This Tool Does

After each patch, the JP client replaces or invalidates the English language file.
This tool automates the manual process by:

1. Fetching the official manifest file.
2. Extracting the current version code for `languagedata_en.loc`.
3. Building the correct download URL using that version code.
4. Downloading the updated file.
5. Replacing the selected existing file with the new version.

No memory editing. No runtime modification.
It strictly downloads and replaces the language file.

---

## Features

* Automatically retrieves current version code
* No manual URL editing required
* Simple file selector for target file
* Safe overwrite using temp file replacement
* Minimal UI (WinForms, VB.NET)

---

## Requirements

* Windows
* .NET Framework / .NET compatible with WinForms (depending on project target)
* Black Desert JP client installed

If the game is installed under `Program Files`, you may need to run this tool as Administrator.

---

## Usage

1. Launch the application, AFTER patching from the Black Desert launcher.
2. Click **Fetch** and choose the correct .loc file.
4. Wait for completion.
5. Launch Black Desert.

The selected file will be overwritten with the updated version.

---

## How It Works (Technical Summary)

The tool reads the plain-text manifest from:

```
https://naeu-o-dn.playblackdesert.com/ads_files
```

Example manifest snippet:

```
languagedata_en.loc    369
languagedata_sp.loc    363
languagedata_fr.loc    360
```

The tool:

* Parses the line matching `languagedata_en.loc`
* Extracts the numeric version code (e.g., `369`)
* Inserts the code into the known download URL template
* Downloads the file
* Atomically replaces the selected file

---

## Safety & Disclaimer

This tool:

* Does NOT inject into the game
* Does NOT modify memory
* Does NOT alter executable files
* Only replaces language data files

Use at your own discretion.
This project is not affiliated with Pearl Abyss.


---
