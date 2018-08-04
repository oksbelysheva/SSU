var action = ["Option1","Option2","Option3","Option4"];
var selected = ["Option5"];

var selectedAction = [];

writeSelected();
writeAvailable();


$('ul').on('click','li',function(){
	var content =  $(this).html();
	var start = content.indexOf(">");
	var finish = content.indexOf("<",start+1);
	selectedAction.push(content.substring(start+1,finish));
	$(this).addClass('selected');
});

function replaceAvailable(){
	if (selectedAction.length==0)
	{
		var tableHTML='';
		tableHTML += '<span>Не выделен ни один элемент!</span>';

		document.getElementById("Error").innerHTML = tableHTML;
	}
	else{
		document.getElementById("Error").innerHTML = '';
	}
	while(selectedAction.length != 0)
	{	
		var name = selectedAction.shift();
		var pos = -1;
		for (var i = 0; i < action.length; i++) {
			if (action[i] === name)
				pos = i;
		}
		if (pos != -1)
		{
			delete action[pos];
			selected.push(name);
		}
	}
	var temp =[];
	for (var i = 0; i < action.length; i++) {
		if (typeof action[i] != "undefined"){
			temp.push(action[i]);
		}
	}
	action = temp;
	selectedAction = [];
	writeSelected();
	writeAvailable();
}


function replaceSelected(){
	if (selectedAction.length==0)
	{
		var tableHTML='';
		tableHTML += '<span>Не выделен ни один элемент!</span>';

		document.getElementById("Error").innerHTML = tableHTML;
	}
	else{
		document.getElementById("Error").innerHTML = '';
	}
	while(selectedAction.length != 0)
	{	
		var name = selectedAction.shift();
		var pos = -1;
		for (var i = 0; i < selected.length; i++) {
			if (selected[i] === name)
				pos = i;
		}
		if (pos != -1)
		{
			delete selected[pos];
			action.push(name);
		}
	}
	var temp =[];
	for (var i = 0; i < selected.length; i++) {
		if (typeof selected[i] != "undefined"){
			temp.push(selected[i]);
		}
	}
	selected = temp;
	selectedAction = [];
	writeSelected();
	writeAvailable();
}

function replaceAllSelected(){
	document.getElementById("Error").innerHTML = '';
	while(selected.length != 0)
	{	
		var name = selected.shift();
		action.push(name);
	}
	var temp =[];
	for (var i = 0; i < selected.length; i++) {
		if (typeof selected[i] != "undefined"){
			temp.push(action[i]);
		}
	}
	selected = temp;
	selectedAction = [];
	writeSelected();
	writeAvailable();
}

function replaceAllAvailable(){
	document.getElementById("Error").innerHTML = '';
	while(action.length != 0)
	{	
		var name = action.shift();
		selected.push(name);
	}
	var temp =[];
	for (var i = 0; i < action.length; i++) {
		if (typeof action[i] != "undefined"){
			temp.push(selected[i]);
		}
	}
	action = temp;
	selectedAction = [];
	writeSelected();
	writeAvailable();
}

function writeSelected(){
	var tableHTML='';

	for (i = 0; i < selected.length ; i++){
		tableHTML += '<div><li><span>' + selected[i] + '</span></li></div>';
	}

	document.getElementById("tableSelected").innerHTML = tableHTML;
}

function writeAvailable(){
	var tableHTML='';

	for (i = 0; i < action.length ; i++){
		tableHTML += '<div><li><span>' + action[i] + '</span></li></div>';
	}

	document.getElementById("tableAvailable").innerHTML = tableHTML;
}