document.getElementById("doubleDelete").addEventListener('click', 
	function(e)
	{
		var str = document.getElementById("inputText").value;
		var splitStr = str.split(' ');
		var signArray = ['!','?',':',';',',','.','\t'];

		while(signArray.length != 0)
		{
			var tempSplit = new Array();
			var currentSign = signArray.shift();
			for (var i = 0; i < splitStr.length; i++) {
				var strCurrent = splitStr[i];
				var splitCurrent = strCurrent.split(currentSign);
				for (var j = 0; j < splitCurrent.length; j++) {
					if (splitCurrent[j].length != 0)
						tempSplit.push(splitCurrent[j]);
				}
			}
			splitStr = tempSplit;
		}

		var doubleSymbols = new Array();


		for (var i = 0; i < splitStr.length; i++) {
			var currentWord = splitStr[i];
			for (var j = 0; j < currentWord.length; j++) {
				for (var k = j+1; k < currentWord.length; k++) {
					if (currentWord[j].toLowerCase()===currentWord[k].toLowerCase())
						doubleSymbols.push(currentWord[j]);
				}
			}
		}

		for (var k = 0; k < doubleSymbols.length; k++) {
			while(str !== str.replace(doubleSymbols[k].toLowerCase(),''))
			{
				str = str.replace(doubleSymbols[k].toLowerCase(),'');
			}
			while(str !== str.replace(doubleSymbols[k].toUpperCase(),''))
			{
				str = str.replace(doubleSymbols[k].toUpperCase(),'');
			}
		}

		document.getElementById("result").value = str;
	});