function CharRemover(str){
    const wordsArr = str.split(' ');

    let duplicatedChars = [];

    wordsArr.forEach(ch => {
        for(let i = 0; i < ch.length; i++) {
            for (let j = i+1; j < ch.length; j++) {
                if(ch[j] == ch[i] && !duplicatedChars.includes(ch[i]))
                duplicatedChars.push(ch[i]);
            }
        }
    });

    let result = str;

    duplicatedChars.forEach(ch => {
        while(result.includes(ch)) {
            result = result.replace(ch, "");
        }
    });
    
    return result;
}
let str = prompt("Введите строку:", "");
alert(CharRemover(str));