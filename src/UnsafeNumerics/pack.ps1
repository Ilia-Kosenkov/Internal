nuget pack UnsafeNumerics.nuspec
ls bin/Release/ | sort -Property LastWriteTime -Descending | select -First 1 | foreach {nuget push $_.FullName -source GPR}