@echo off

set in_path=%cd%/protos/
set out_path=%cd%/protos/
set tool_path=%cd%/protoc/protoc

rem ╡Иурнд╪Ч
for /R %in_path% %%i in (*.proto) do echo %%~ni     
for /R %in_path% %%i in (*.proto) do %tool_path% -I=%in_path% --python_out=%out_path%  %%i
pause