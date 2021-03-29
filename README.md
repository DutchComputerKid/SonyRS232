# SonyRS232

SonyRS232 is a tool that can talk to CDP-D11 rack-mounted CD players for wired remote control.

  - Offers full playback and transport control.
  - Supports CDP-D11 and probably the CDP-D12 as well.
  - Buttons on the unit itself correspond exactly with the program's buttons and more.
  - Can be used to diagnose units if they behave abnormally.

Using the Interface guide of the CDP-D11 the program sends hexadecimal codes and commands the CD player accepts as remote control.
Simply connect an RS232 cable to the unit and your computer, open the program and off you go.
The program sends commands but also can intercept and read some status messages the CD player sends back. Things like ejecting the disc, no CD in drive and playback start.


### Installation
You can either build from source, or open the pre-compiled EXE.
SonyRS232 does not save anything so it's portable as long as you have a nullmodem cable.

