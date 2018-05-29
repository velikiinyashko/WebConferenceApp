'use strict';

var startButton = document.getElementById('startButton');
var callButton = document.getElementById('callButton');

var videoLocal = document.querySelector('video#videoLocal');
var videoRemove = document.querySelector('video#videoRemove');

startButton.onclick = start;

function start() {
    console.log(' press start button');
    startButton.disablet = true;
    navigator.mediaDevices.getUserMedia({
        audio: true,
        video: true
    })
        .catch(function (e) {
            console.log('getUserMedia() error: ', e);
        });
}
