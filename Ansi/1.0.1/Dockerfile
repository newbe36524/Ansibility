FROM microsoft/aspnetcore:1.0.1
Add source.list /etc/apt/sources.list
RUN apt-get update
RUN apt-get install ansible -y
RUN apt-get install ssh -y
RUN apt-get install python-pip -y
RUN pip install --upgrade pip -i http://mirrors.aliyun.com/pypi/simple
RUN pip install pywinrm -i http://mirrors.aliyun.com/pypi/simple --trusted-host mirrors.aliyun.com
