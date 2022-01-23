function solve() {
   document.querySelector('#btnSend').addEventListener('click', onClick);

   function onClick() {
      let textAreaInput = document.querySelector('div#inputs textarea');
      let input = JSON.parse(textAreaInput.value);

      let restaurants = [];

      for (const line of input) {
         let [restaurantName, workersInput] = line.split(' - ');
         let workers = [];

         for (const worker of workersInput.split(', ')) {
            let [workerName, workerSalary] = worker.split(' ');
            workers.push({
               name: workerName,
               salary: Number(workerSalary)
            })
         }

         let restaurant = {
            name: restaurantName,
            workers,
            get averageSalary() {
               return this.workers.reduce((a, x) => a + x.salary / this.workers.length, 0)
            },
            get bestSalary() {
               return Math.max(...this.workers.map(x => x.salary));
            }
         }

         if (!restaurants[restaurant.name]) {
            restaurants[restaurant.name] = restaurant;
         } else {
            restaurant.workers.forEach(w => {
               if (!restaurants[restaurant.name].workers.some(x => x.name === w.name)) {
                  restaurants[restaurant.name].workers.push(w);
               }
            })
         }
      }

      let bestRestaurant = Object.entries(restaurants).sort((a, b) => b[1].averageSalary - a[1].averageSalary)[0][1];
      let bestWorkers = bestRestaurant.workers.sort((a, b) => b.salary - a.salary);

      let bestRestaurantOutputElement = document.querySelector('div#bestRestaurant p');
      bestRestaurantOutputElement.textContent =
         `Name: ${bestRestaurant.name} Average Salary: ${bestRestaurant.averageSalary.toFixed(2)} Best Salary: ${bestRestaurant.bestSalary.toFixed(2)}`;

      let bestWorkersOutputElement = document.querySelector('div#workers p');
      let bestWorkersOutputText = '';
      for (const worker of bestWorkers) {
         bestWorkersOutputText += `Name: ${worker.name} With Salary: ${worker.salary} `;
      }
      bestWorkersOutputElement.textContent = bestWorkersOutputText.trimEnd();
   }
}
