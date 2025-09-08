let express = require('express');           //express 모듈을 가져온다.
let app = express();                        //express를 App 이름으로 정의헉고 사용한다.

app.get('/' , function(req, res){
    res.send('Hello world');
});

app.listen(3000, function(){

    console.log('listening on port 3000');     // 3000포트에서 입력을 대기 한다.
})