let flags = [];
let total = 0;
let score = 0;
let correctAnswer = "";
const hostName = window.location.hostname;
const port = window.location.port;
const pathName = window.location.pathname.split("/");

const flagDeckIdentifier = pathName[pathName.length - 1];

console.log(flagDeckIdentifier);

const setAllowInput = (allowed) => {
    $("#answerInput").prop("disabled", !allowed);
}

const shuffle = (values) => {
  let index = values.length,
    randomIndex;

  // While there remain elements to shuffle.
  while (index != 0) {
    // Pick a remaining element.
    randomIndex = Math.floor(Math.random() * index);
    index--;

    // And swap it with the current element.
    [values[index], values[randomIndex]] = [values[randomIndex], values[index]];
  }

  return values;
}

const askQuestion = () => {
    $("#answerInput").val("");
    $("#answerInput").removeClass("answer-correct");
    $("#answerInput").removeClass("answer-incorrect");
    setAllowInput(true);
    console.log(flags);

    if (flags.length <= 0) {
        $("#section-quiz").addClass("hidden");
        $("#section-end").removeClass("hidden");
        $("#result-text").text(`Je score is ${(score / total) * 10}!`);
        return;
    }
    if (total === 0) total = flags.length;

    const currentFlag = flags.shift();

    $("#flagImg").attr("src", currentFlag.imageURL);
    correctAnswer = currentFlag.correctAnswer.toLowerCase();
}

const answerQuestion = () => {
    const answer = $("#answerInput").val().toLowerCase();

    if (answer === correctAnswer) {
        score++;
        $("#answerInput").addClass("answer-correct");
    } else {
        $("#answerInput").addClass("answer-incorrect");
    }

    skipQuestion();
}

const skipQuestion = () => {
    setAllowInput(false);

    setTimeout(() => {
        askQuestion();
    }, 1000);
}

const postScore = () => {
    const achievedByName = $("#achievedByName").val();

    const data = {
        achievedByName,
        scoreNumber: score,
    };

    fetch(`https://${hostName}:${port}/api/flagDecks/${flagDeckIdentifier}`, {
        method: "POST",
        headers: {'Content-Type': 'application/json'}, 
        body: JSON.stringify(data)
    }).then(res => {
        console.log("Request complete! response:", res);
        window.location.href = "/FlagDecks/Choose";
    });
}


fetch(`https://${hostName}:${port}/api/FlagDecks/${flagDeckIdentifier}`)
    .then((response) => response.json())
    .then((data) => {
        $("#quizTitle").text(`${data.name} quiz`);
        flags = shuffle(data.flags);
    })
    .then(() => askQuestion());

