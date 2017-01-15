# Installation

## Docker

You can do as follow steps tell to build Ansibility.

### Build Ansi

Ansi is the base image for Ansibility, you can build it use `/Ansi/buildAll.ps1`.

The powershell script will build Ansi images, those contains aspnetcore and Ansible.

> Ansi Dockerfile use some faster apt-get mirrors in China , you can change it by yourself.

### Build Ansibility

using `/src/Ansibility.Web/build.cmd` ,you will get a Ansibility image and Ansibility container which hosted on 8000 port, and you can visit <http://localhost:8000/swagger> to view swagger ui.
