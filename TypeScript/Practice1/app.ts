let a: number = "Hello TS12352";
console.warn(a);

function users<T>(data: T): T {
    return data;
}

console.warn(users(5));