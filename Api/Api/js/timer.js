let counter = 0;
let interval;
let target;

function startCounting(time) {
  if (!isInitialised()) {
    // First time start is called
    target = getTimerValue();
    setTimerReadonly(true);
  }
  if (isStopped()) {
    interval = setInterval(checkCount, 1000);
    setTimerButtonStop();
  } else {
    clearInterval(interval);
    setTimerButtonStart();
  }
}

function setTimerButtonStart() {
  let btn = document.getElementById("startButton");
  btn.value = "START";
  btn.classList.remove(...btn.classList);
  btn.classList.add("timer-button");
}
function setTimerButtonStop() {
  let btn = document.getElementById("startButton");
  btn.value = "STOP";
  btn.classList.remove(...btn.classList);
  btn.classList.add("active-timer-button");
}

function isStopped() {
  let btn = document.getElementById("startButton");
  return btn.value === "START";
}
function isInitialised() {
  return counter > 0;
}
function getTimerValue() {
  let userTimeMinutes = document.getElementById("timerMinutes").value;
  let userTimeSeconds = document.getElementById("timerSeconds").value;
  return parseInt(userTimeMinutes * 60) + parseInt(userTimeSeconds);
}

function checkCount() {
  console.log(counter);
  counter++;

  if (counter === target) {
    clearInterval(interval);
  }

  let secondsLeft = target - counter;
  let reminderSeconds = secondsLeft % 60;
  let minutesLeft = (secondsLeft - reminderSeconds) / 60;

  document.getElementById("timerMinutes").value = minutesLeft;
  document.getElementById("timerSeconds").value =
    reminderSeconds < 10 ? "0" + reminderSeconds : reminderSeconds;
}

function resetCounter() {
  if (interval !== undefined) clearInterval(interval);
  if (isInitialised()) {
    document.getElementById("timerMinutes").value = target / 60;
    document.getElementById("timerSeconds").value = "00";
    counter = 0;
    setTimerButtonStart();
    setTimerReadonly(false);
  }
}

function setTimerReadonly(val) {
  document.getElementById("timerMinutes").readOnly = val;
  document.getElementById("timerSeconds").readOnly = val;
}

function clearMinutesBox() {
  if (!isInitialised()) {
    document.getElementById("timerMinutes").value = "";
    document.getElementById("timerSeconds").value = "00";
  }
}

function validateTimerBox() {
  if (
    document.getElementById("timerMinutes").value.length == 0 ||
    document.getElementById("timerMinutes").value.length > 2
  ) {
    document.getElementById("timerMinutes").value = "25";
  }
}
document.getElementById("startButton").addEventListener("click", startCounting);
document.getElementById("resetButton").addEventListener("click", resetCounter);
document
  .getElementById("timerMinutes")
  .addEventListener("blur", validateTimerBox);
document
  .getElementById("timerMinutes")
  .addEventListener("click", clearMinutesBox);
