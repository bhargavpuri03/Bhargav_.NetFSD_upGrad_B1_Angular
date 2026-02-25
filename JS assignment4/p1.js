 let books = [
  { id: 1, title: "JavaScript Basics", price: 450, stock: 10 },
  { id: 2, title: "React Guide", price: 650, stock: 5 },
  { id: 3, title: "Node.js Mastery", price: 550, stock: 8 },
  { id: 4, title: "CSS Complete", price: 300, stock: 12 }
];

let titles = books.map(b => b.title);
console.log(titles);

let totalValue = books.reduce((sum, b) => sum + (b.price * b.stock), 0);
console.log(totalValue);

let costlyBooks = books.filter(b => b.price > 500);
console.log(costlyBooks);

let updatedPrices = books.map(b => ({
  ...b,
  price: b.price * 1.05
}));
console.log(updatedPrices);

let sortedBooks = [...books].sort((a,b) => a.price - b.price);
console.log(sortedBooks);

let removeId = 2;
books = books.filter(b => b.id !== removeId);
console.log(books);

let outOfStock = books.some(b => b.stock === 0);
console.log(outOfStock);