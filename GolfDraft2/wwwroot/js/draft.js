"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/draftHub").build();




connection.on("NotifyDraft", function (user, playerID) {
    var encodedMsg = user + " picked " + playerID;
    var li = document.createElement("li");
    li.textContent = encodedMsg;
    document.getElementById("messagesList2").appendChild(li);
});

connection.on("AddPlayer", playerID => {
    var li = document.createElement("li");
    li.textContent = playerID;
    document.getElementById("myTeamList").appendChild(li);
});

connection.on("RemoveDrafted", playerID => {
    var player = document.getElementById(playerID + 'li');
    player.parentElement.removeChild(player);
});

connection.on("ShowUsers", users => {
    users.forEach(element => {
        var li = document.createElement("li");
        li.textContent = element;
        li.id = element;
        document.getElementById("conUsers").appendChild(li);
    });
});

//connection.on("NewUser", user => {
//    var li = document.createElement("li");
//    li.id = user;
//    li.textContent = user;
//    document.getElementById("conUsers").appendChild(li);
//});

//connection.on("OldUser", user => {
//    var remove = document.getElementById(user);
//    remove.parentElement.removeChild(remove);
//});


connection.start().catch(function (err) {
    return console.error(err.toString());
});

function draftPlayer(clicked_id) {
    var playerID = clicked_id;
    var user = document.getElementById("userName").value;
    var userID = document.getElementById("userID").value;
    connection.invoke("DraftPlayer", user, userID, playerID).catch(function (err) {
        return console.error(err.toString());
    });
    event.preventDefault();
}


