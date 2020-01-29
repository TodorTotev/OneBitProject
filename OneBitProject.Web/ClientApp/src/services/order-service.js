const orderService = {
    addOrder: newData => {
      return new Promise((resolve, reject) => {
        fetch("api/Orders/Create", {
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
    getOrder: id => {
      return new Promise((resolve, reject) => {
        fetch(`/api/Orders/Get/${id}`, {
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
        fetch("api/Orders/Update", {
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
    deleteOrder: id => {
      return new Promise((resolve, reject) => {
        fetch(`api/Orders/Delete/${id}`, {
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
  
  export default orderService;
  