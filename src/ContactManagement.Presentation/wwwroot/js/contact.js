document.getElementById("searchInput").addEventListener("keyup", function () {
  let filter = this.value.toLowerCase();
  let rows = document.querySelectorAll("#contactTable tbody tr");

  rows.forEach((row) => {
    row.style.display = row.innerText.toLowerCase().includes(filter)
      ? ""
      : "none";
  });
});

function sortTable(n) {
  let table = document.getElementById("contactTable");
  let rows = Array.from(table.rows).slice(1);
  let asc = table.getAttribute("data-sort") !== "asc";

  rows.sort((a, b) => {
    let x = a.cells[n].innerText;
    let y = b.cells[n].innerText;
    return asc ? x.localeCompare(y) : y.localeCompare(x);
  });

  rows.forEach((row) => table.appendChild(row));
  table.setAttribute("data-sort", asc ? "asc" : "desc");
}

function saveRow(button) {
  let row = button.closest("tr");
  let id = row.getAttribute("data-id");

  let dateText = new Date(row.cells[1].innerText);
  let yyyy = dateText.getFullYear();
  let mm = String(dateText.getMonth() + 1).padStart(2, '0');
  let dd = String(dateText.getDate()).padStart(2, '0');

  let data = {
    Id: id,
    Name: row.cells[0].innerText,
    DateOfBirth: `${yyyy}-${mm}-${dd}`, // "YYYY-MM-DD"
    Married: row.cells[2].innerText.toLowerCase() === "true",
    Phone: row.cells[3].innerText,
    Salary: parseFloat(row.cells[4].innerText.replace(",", ""))
  };

  fetch("/Home/Update", {
    method: "POST",
    headers: { "Content-Type": "application/json" },
    body: JSON.stringify(data)
  })
    .then(res => {
      if (!res.ok) throw new Error("Update failed");
      alert("Saved");
    })
    .catch(err => alert(err));
}

function deleteRow(button) {
  let row = button.closest("tr");
  let id = row.getAttribute("data-id");

  fetch("/Home/Delete?id=" + id, {
    method: "POST",
  }).then(() => {
    row.remove();
  });
}
