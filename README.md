# HomeAutomation
Home Automation is a central server platform for automating your home.

## Features
* Angular user interface
* RESTful API for UI extensability
* MQTT backhaul for communicating with IoT devices
* MongoDb data store.

### General
This project is intended to run on a small Linux server, but when built from source, it can be run on any platform that is capable of running dotnet core.
The current deployment server has 2 phyical NICs, one as a DHCP client on the main home network, the second as a DHCP server, powering a seperate subnet exclusively for the IoT devices.

### Security
The MQTT library used to provide the MQTT functionality supports a miriad of security protocols and standards. ASP.NET Core with NGINX has built in support for TLS 1.2. The IoT devices are on a seperate subnet, and do not have direct internet connections. All IoT traffic is routed through the central server as an edge server, and any outgoing information is controlled via the server.

## Libraries in use
A big thank you to all the libraries we depend on for this project.
* MQTTnet - https://github.com/chkr1011/MQTTnet
* AutoFixture - https://github.com/AutoFixture/AutoFixture
* Moq - https://github.com/moq/moq4
* xUnit - https://github.com/xunit/xunit

And a big thank you to the folks over at Studio 3T for providing me with a free license for their product. 