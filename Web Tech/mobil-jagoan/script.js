var myRoad
var myCar
var myOpponent = []
var theScore = []

function startGame() {
    myGameArea.start()

    myRoad = new component(300, 600, 'gray', 330, 0)

    myCar = new component(55, 110, 'red', 415, 450)

    leftField = new component(330, 600, 'greenyellow', 0, 0)
    rightField = new component(330, 600, 'greenyellow', 630, 0)

    border = new component(300, 20, 'transparent', 330, 560)

    // myOpponent = new component(55, 110, 'green', 340, 0)
    // myOpponent = new component(55, 110, 'green', 415, 0)
    // myOpponent = new component(55, 110, 'green', 490, 450)
    // myOpponent = new component(55, 110, 'green', 565, 450)
}

var myGameArea = {
    canvas: document.createElement('canvas'),
    start: function() {
        document.getElementById('start').style.display = 'none'
        document.getElementById('game-ui').style.display = 'block'
        this.canvas.width = 960
        this.canvas.height = 600
        this.canvas.style.backgroundColor = '#252525'
        this.context = this.canvas.getContext('2d')
        this.frameNo = 0
        document.body.insertBefore(this.canvas, document.body.childNodes[0])
        this.interval = setInterval(updateGameArea, 20)

        window.addEventListener('keydown', function(e) {
            myGameArea.keys = (myGameArea.keys || [])
            myGameArea.keys[e.keyCode] = true
        })
        window.addEventListener('keyup', function(e) {
            myGameArea.keys[e.keyCode] = false
        })
    },
    clear: function() {
        this.context.clearRect(0, 0, this.canvas.width, this.canvas.height)
    },
    stop: function() {
        this.context = clearInterval()
        document.getElementById('result').style.display = 'block'
        document.querySelector('canvas').style.display = 'none'
        document.getElementById('game-ui').style.display = 'none'
        if(this.frameNo > 3000) {
            document.getElementById('title').innerHTML = 'You Win'
        } else {
            document.getElementById('title').innerHTML = 'Game Over'
        }
    }
}

function component(width, height, color, x, y, type) {
    this.type = type
    if(this.type == 'image') {
        this.image = new Image()
        this.image.src = color
    }
    this.width = width
    this.height = height
    this.x = x
    this.y = y
    this.update = function() {
        ctx = myGameArea.context
        ctx.fillStyle = color
        ctx.fillRect(this.x, this.y, this.width, this.height)
    },
    this.crashWith = function(otherobj) {
        var myleft = this.x
        var myright = this.x + (this.width)
        var mytop = this.y
        var mybottom = this.y + (this.height)
        var otherleft = otherobj.x
        var otherright = otherobj.x + (otherobj.width)
        var othertop = otherobj.y
        var otherbottom = otherobj.y + (otherobj.height)
        var crash = true
        if((mybottom < othertop) || (mytop > otherbottom) || (myright < otherleft) || (myleft > otherright)) {
            crash = false
        }
        return crash
    }
}

var score = 0
var speed = 4

function updateGameArea() {
    if(myGameArea.frameNo > 3000) {
        myGameArea.stop()
    }
    if(myGameArea.frameNo > 2000) {
        speed = 8
    }
    if(myGameArea.frameNo > 1000) {
        speed = 6
    }

    for(i = 0; i < myOpponent.length; i++) {
        if(myCar.crashWith(myOpponent[i])) {
            myGameArea.stop()
        }
    }
    for(i = 0; i < theScore.length; i++) {
        if(border.crashWith(theScore[i])) {
            theScore[i].y += myGameArea.canvas.height
            score += theScore[i].width
        }
    }

    if(myCar.crashWith(leftField)) {
        myCar.x += 5
    }
    if(myCar.crashWith(rightField)) {
        myCar.x -= 5
    }

    myGameArea.clear()
    myGameArea.frameNo++

    myRoad.update()
    leftField.update()
    rightField.update()

    // KEY KIRI
    if(myGameArea.keys && myGameArea.keys[37]) {
        myCar.x -= 5
    }

    // KEY KANAN
    if(myGameArea.keys && myGameArea.keys[39]) {
        myCar.x += 5
    }

    if((myGameArea.frameNo == 1) || everyinterval(100)) {
        var random = Math.floor(Math.random() * 4)
        var random2 = Math.floor(Math.random() * 4)
        var x = [340, 415, 490, 565]
        var car = ['green', 'yellow', 'red', 'black']
        var scoreWidth = [50, 100, 150, 200]

        myOpponent.push(new component(55, 110, car[random2], x[random], -110))
        theScore.push(new component(scoreWidth[random2], 110, 'transparent', x[random], -110))
    }

    for(i = 0; i < myOpponent.length; i++) {
        myOpponent[i].y += speed * 2
        myOpponent[i].update()
    }
    for(i = 0; i < theScore.length; i++) {
        theScore[i].y += speed * 2
        theScore[i].update()
    }

    border.update()

    myCar.update()

    document.getElementById('playerName').innerHTML = 'NAME: ' + document.getElementById('name').value
    document.getElementById('score').innerHTML = 'SCORE: ' + score
    document.getElementById('speed').innerHTML = 'SPEED: ' + speed*10 + 'km/h'

    document.getElementById('result-name').innerHTML = document.getElementById('playerName').innerHTML
    document.getElementById('result-score').innerHTML = document.getElementById('score').innerHTML

    console.log(myGameArea.frameNo)
}

function everyinterval(n) {
    if((myGameArea.frameNo / n) % 1 == 0) {
        return true
    }
    return false
}