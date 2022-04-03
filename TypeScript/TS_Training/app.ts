
export {};

function add(n1: number, n2: number, showResult: boolean) {
    /*if(typeof n1 !=='number' || typeof n2 !=='number'){
        throw new Error('INcorrect input')
    }*/
    const res = n1 + n2;
    if (showResult)
        console.log(res);

}

let num1 = 41;
const num2 = 5.10;
const showResult = false;

add(num1, num2, showResult);
