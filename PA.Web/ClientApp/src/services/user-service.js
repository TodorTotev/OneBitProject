const userService = {
  loadCustomers: () => {
    return new Promise((resolve, reject) => {
      fetch("api/Customers/GetAll", {
        method: "GET"
      })
        .then(response => response.json())
        .then(data => resolve(data))
        .then(err => reject(err));
    });
  },
  addCustomer: newData => {
    return new Promise((resolve, reject) => {
      fetch("api/Customers/Create", {
        method: "POST",
        headers: {
          Accept: "application/json",
          "Content-Type": "application/json"
        },
        body: JSON.stringify(newData)
      })
        .then(res => {
          if (res.status === 400) {
            resolve(res.json);
          }
          resolve();
        })
        .catch(err => reject(err));
    });
  },
  getCustomer: id => {
    return new Promise((resolve, reject) => {
      fetch(`/api/Customers/Get/${id}`, {
        method: "GET",
        headers: {}
      })
        .then(response => response.json())
        .then(data => resolve(data))
        .catch(err => reject(err));
    });
  },
  updateCustomer: data => {
    return new Promise((resolve, reject) => {
      fetch("api/Customers/Update", {
        method: "PUT",
        headers: {
          Accept: "application/json",
          "Content-Type": "application/json"
        },
        body: JSON.stringify(data)
      })
        .then(res => {
          if (res.status === 400) {
            resolve(res.json);
          }
          resolve();
        })
        .catch(err => reject(err));
    });
  },
  deleteCustomer: id => {
    return new Promise((resolve, reject) => {
      fetch(`api/Customers/Delete/${id}`, {
        method: "DELETE",
        headers: {
          "Content-Type": "application/json"
        }
      })
        .then(res => {
          if (res.status === 400) {
            resolve(res.json);
          }
          resolve();
        })
        .catch(err => reject(err));
    });
  }
};

export default userService;
