let tomatoManager = (function () {
  function privateInit() {
    //document.getElementById("test").addEventListener("click", handleClick);

    axios
      //.get("http://jsonplaceholder.typicode.com/todos")
      .get(
        "http://localhost:55808/api/entry/B4376B7A-6718-4151-976E-4FE527998C1A"
      )
      .then(function (response) {
        console.log(response);
        let entries = response.data;
        setOutput(entries);
      })
      .catch(function (error) {
        setOutput(error);
      });
  }

  function setOutput(entry) {
    let output = "";
    _.each(entry.Entries, (value) => {
      console.log(entry);
      output += `${new Date(value.Date)}<br/>`;
    });

    document.getElementById("output").innerHTML += output;
  }

  return {
    init: privateInit,
  };
})();
