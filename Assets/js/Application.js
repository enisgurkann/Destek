  $(document).ready(function () {
   
  });



  function Pr_DeleteRow(row, grid) {
      var d = row.parentNode.parentNode.rowIndex;
      document.getElementById(grid).deleteRow(d);
  }

  function AlertReset() {
      $("#toggleCSS").attr("href", "../plugins/alertify/alertify.default.css");
      alertify.set({
          labels: { ok: "Tamam", cancel: "Vazgeç" },
          delay: 5000,
          buttonReverse: true,
          buttonFocus: "ok"
      });
  }

