# nslookup2csv

[![Build status](https://ci.appveyor.com/api/projects/status/76xqkgtimheax97j?svg=true)](https://ci.appveyor.com/project/mamori017/nslookup2csv)
[![codecov](https://codecov.io/gh/mamori017/nslookup2csv/branch/master/graph/badge.svg)](https://codecov.io/gh/mamori017/nslookup2csv)
[![Codacy Badge](https://api.codacy.com/project/badge/Grade/9b0055dfd5f94715aa87af8f9559438e)](https://www.codacy.com/app/mamori017/nslookup2csv?utm_source=github.com&amp;utm_medium=referral&amp;utm_content=mamori017/nslookup2csv&amp;utm_campaign=Badge_Grade)
[![CodeFactor](https://www.codefactor.io/repository/github/mamori017/nslookup2csv/badge)](https://www.codefactor.io/repository/github/mamori017/nslookup2csv)
[![BCH compliance](https://bettercodehub.com/edge/badge/mamori017/nslookup2csv?branch=master)](https://bettercodehub.com/)
[![Release](https://img.shields.io/github/release/mamori017/nslookup2csv.svg)](https://github.com/mamori017/nslookup2csv/releases/latest)
[![License](https://img.shields.io/github/license/mamori017/nslookup2csv.svg)](https://github.com/mamori017/nslookup2csv/blob/master/LICENSE)

## Overview

Windows nslookup command execute results change to one line, and convert to csv file.

## Requirement

- .NET Framework 4.5
- [mamori017/Common](https://github.com/mamori017/Common)
  - https://github.com/mamori017/Common.git
  - Add File As Link.

## Build

|Configuration |Detail |
|:-----|:-----|
|Debug | Local build|
|Release |AppVeyor CI build.|

Configuration difference is Common repository file reference method. 

Check .csproj for the difference.

## Usage

1. Execute nslookup with cmd.exe and output it to a text file.
2. Drop the text file to the nslookup2csv.exe to output the csv file.

## Sample

1. Execute sample/Output.bat and TargetResults.txt is created.
2. TargetResults.txt drop to nslookup2csv.exe, Finally TargetResults.csv is created.

## Licence
[MIT](https://github.com/mamori017/nslookup2csv/blob/master/LICENSE)

## Author
[mamori017](https://github.com/mamori017)
