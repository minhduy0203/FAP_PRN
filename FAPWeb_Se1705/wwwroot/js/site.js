"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/sessionhub").build();

connection.start()
    .then(function () {
        connection.invoke("SetUser").catch(function (err) {
            return console.error(err.toString());
        });
    }
    ).catch(
        function (err) {
            return console.error(err.toString());
        }
    );

connection.on("SessionAdd", () => {
    location.reload();
});

