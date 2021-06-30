REM Script für webdeploy, die Datei *.publishsettings muss die Variable userName und userPWD enthalten

cd /d %~dp0

"C:\Program Files (x86)\IIS\Microsoft Web Deploy V3\msDeploy.exe" -verb:sync -source:iisApp="C:\@github\webhook\webhook\bin\Release\netcoreapp3.1\publish"  -allowUntrusted -dest:iisApp="aatest.loftsoft.ch",publishSettings="aatest.loftsoft.ch.publishsettings"

REM -allowUntrusted -whatif
REM "C:\Program Files (x86)\IIS\Microsoft Web Deploy V3\msDeploy.exe" -verb:sync -source:iisApp="C:\@Tmp\DeployTest\DeployTest\obj\Release\netcoreapp2.1\PubTmp\Out"  -allowUntrusted -dest:iisApp="aatest.loftsoft.ch",publishSettings="C:\@Tmp\DeployTest\aatest.loftsoft.ch.publishsettings"
REM "C:\Program Files (x86)\IIS\Microsoft Web Deploy V3\msDeploy.exe" -verb:sync -source:iisApp="C:\@Tmp\DeployTest\DeployTest\obj\Release\netcoreapp2.1\PubTmp\Out"  -allowUntrusted -dest:iisApp="aatest.loftsoft.ch",publishSettings="C:\@Tmp\DeployTest\aatest.loftsoft.ch.publishsettings"
REM "C:\Program Files (x86)\IIS\Microsoft Web Deploy V3\msDeploy.exe"
REM "C:\Program Files (x86)\IIS\Microsoft Web Deploy V3\msDeploy.exe" -verb:dump -source:package="C:\@Tmp\DeployTest2\drop\aa-txt-repo-1.0.0.289-RC.zip"  
pause