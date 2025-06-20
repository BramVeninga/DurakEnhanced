# DurakEnhanced 🎴

DurakEnhanced is a 2-player implementation of the traditional Russian card game **Durak**, built with **C# 7.3** using **Windows Forms**. The goal of the game is to avoid being the last player with cards — the loser is the "Durak" (fool).

This project supports basic game flow, turn logic, card rules, and TCP-based client-server communication for multiplayer gameplay.

Within the TCP there are 2 roles, a host and a guest. 
The connection process is pretty self explanitory. When a host starts a game, he is met with a waiting screen where his connection details are shown.
When a guest wishes to enter a game he or she needs to enter the host' connection details.
The connection details consist of an IP and a port.
---

## 📦 Features

- 🔁 Turn-based Durak logic (attacker vs. defender)
- 🃏 36-card deck (6–Ace of each suit)
- ♣️ Suit & rank comparison rules with trump support
- 🧠 Separate `Rules` and `GameEngine` classes
- 🌐 Basic networking using TCP (host/join a game)
- 🖼️ Simple UI components (WinForms controls)

---

## 📁 Project Structure

```
DurakEnhanced/
│
├── Controls/             # UserControls like CreateGameControl, WaitingScreenControl
├── Forms/                # MainForm and navigation
├── GameLogic/            # Card, Player, GameEngine, Rules (Durak core logic)
├── Networking/           # TCP server/client via NetworkManager
├── Properties/           # Resources (e.g., game logo)
└── Program.cs            # Entry point
