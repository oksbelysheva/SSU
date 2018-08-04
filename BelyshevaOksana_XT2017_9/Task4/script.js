function DoCPExit()
{
if(window != window.parent && window.parent && window.parent["DoCPExit"] !== undefined )
{
window.parent.DoCPExit();
}
else
{
if(window.top == self)
{
var win = window.open("","_self");
win.close();
}
else
{
var win = window.top.open("","_self");
win.top.close();
}
}
}