
$("#loadBtn").click(function () {
    $.ajax({
        url: "http://localhost:5294/api/students",
        type: "GET",
        success: function (response) {
            $("#students").html("");
            response.data.forEach(student => {
                $("#students").append(`
                    <div style="border:1px solid black; padding:10px; margin:10px;">
                        <h3>${student.name}</h3>

                        <p>Age: ${student.age}</p>

                        <p>Department: ${student.departmentName}</p>

                        <p>Supervisor: ${student.supervisorName ?? "No Supervisor"}</p>
                    </div>
                `);
            });
        },
        error: function (xhr) {
            alert("Error loading students");
        }
    });
});
