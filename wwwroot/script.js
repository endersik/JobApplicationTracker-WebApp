const uri = "api/Applications";

function addItem() {
    const company = document.getElementById("company");
    const position = document.getElementById("position");
    const deadline = document.getElementById("deadline");
    const isApplied = document.getElementById("isApplied");

    const item = {
        company: company.value.trim(),
        position: position.value.trim(),
        deadline: deadline.value,
        applied: isApplied.value == "on" ? true : false
    }

    fetch(uri, {
        method: 'POST',
        headers: {
          'Accept': 'application/json',
          'Content-Type': 'application/json'
        },
        body: JSON.stringify(item)
      })
}