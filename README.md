Windows Service Example
=======================

This is example of windows service project.

Test
----

Use **sc** command line program to install, start, stop and delete service.

```
sc create WindowsServiceExample binpath= "C:\example-windows-service\net40\WindowsService.exe"
```

```
sc start WindowsServiceExample
```

```
sc stop WindowsServiceExample
```

```
sc delete WindowsServiceExample
```
