let cart = [
  { id: 1, product: "Laptop", price: 60000, qty: 1 },
  { id: 2, product: "Headphones", price: 2000, qty: 2 },
  { id: 3, product: "Mouse", price: 800, qty: 1 }
];

let total = cart.reduce((sum,item)=> sum + (item.price*item.qty),0);
console.log(total);

cart = cart.map(item =>
  item.id === 3 ? {...item, qty: item.qty+1} : item
);
console.log(cart);

cart = cart.filter(item => item.id !== 2);
console.log(cart);

cart = cart.map(item =>
  item.price > 10000
  ? {...item, price: item.price * 0.9}
  : item
);
console.log(cart);

let sortedCart = [...cart].sort((a,b)=>
  (a.price*a.qty)-(b.price*b.qty)
);
console.log(sortedCart);

console.log(cart.some(item => item.price > 50000));
console.log(cart.every(item => item.qty > 0));