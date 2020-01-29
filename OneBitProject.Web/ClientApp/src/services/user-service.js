import axios from "axios";

const userService = {
  loadCustomers: () => {
      return new Promise((resolve, reject) => {
          fetch("api/Customers/GetAll", {
              method:'GET'
          })
          .then(response => response.json())
          .then(data => resolve(data))
          .then(err => reject(err))
      })
  },
  addCustomer: (newData) => {
    return new Promise((resolve, reject) => {
      fetch("api/Customers/Create", {
        method: "POST",
        headers: {
          Accept: "application/json",
          "Content-Type": "application/json"
        },
        body: JSON.stringify(newData)
      }).then(res => {
        if (res.status === 400){
          resolve(res.json)
        }
        resolve()
      }).catch(err => reject(err));
    })
  }
};

export default userService;
