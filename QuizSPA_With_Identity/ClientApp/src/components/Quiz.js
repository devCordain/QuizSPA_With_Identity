import React, { Component } from 'react';
import authService from './api-authorization/AuthorizeService'

export class Quiz extends Component {
    static displayName = Quiz.name;

    constructor(props) {
        super(props);
        this.submitAnswer = this.submitAnswer.bind(this);
        this.saveHighscore = this.saveHighscore.bind(this);
        this.state = {
            quizFinished: false,
            quizStarted: false,
            questions: [],
            currentQuestion: 0,
            answerOptions: [],
            answered: false,
            answers: [],
            correctAnswers: 0,
            loading: true,
            userName: 'temp'
        }
    }

    resetState = () => {
        this.setState(this.initialState);
    }

    componentDidMount() {
        this.getData();
    }

    submitAnswer(answer) {
        if (answer.isCorrect) this.setState({ correctAnswers: this.state.correctAnswers + 1 });
        if (this.state.currentQuestion + 1 >= this.state.questions.length) this.setState({ quizFinished: true });
        else {
            this.setState({ currentQuestion: this.state.currentQuestion + 1, answerOptions: this.state.answers.filter(x => x.questionId === this.state.questions[this.state.currentQuestion + 1].id) });
        }
    };

    async saveHighscore() {
        const token = await authService.getAccessToken();
        let response = await fetch('api/highscores', {
            method: 'POST',
            headers: 
                !token ? {} : {
                    'Authorization': `Bearer ${token}`,
                    'Accept': 'application/json',
                    'Content-Type': 'application/json'
            },
            body: JSON.stringify({ username: this.state.userName, score: this.state.correctAnswers })
        });
        let result = await response.json();
        console.log(result);
        this.resetState();
    }

    startQuiz = () => {
        this.setState({quizStarted: true});
    }

    runQuiz = () => {
        if (!this.state.quizFinished) {
            if (!this.state.quizStarted) {
                return (
                    <div>
                        <button onClick={this.startQuiz}> Start Quiz </button>
                    </div>
                );

            } else {
                let question = this.state.questions[this.state.currentQuestion];
                let answerOptions = this.state.answerOptions;
                return (
                    <div>
                        <p>Number of correct answers: {this.state.correctAnswers}</p>
                        <p>{question.text}</p>
                        <div>
                            {answerOptions.map(answer => <button key={answer.id} onClick={() => this.submitAnswer(answer)}>{answer.text}</button>)}
                        </div>
                    </div>
                );
            }
        }
        else {
            return (
                <div>
                    <p>{this.state.userName} answered {this.state.correctAnswers} out of {this.state.questions.length} questions correctly!</p>
                    <button onClick={this.resetState}> Try again without saving</button>
                    <button onClick={this.saveHighscore}> Save your score! </button>
                </div>
            );
        }
    }

    render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : this.runQuiz();

        return (
            <div>
                {contents}
            </div>
        );
    }

    async getData() {
        const token = await authService.getAccessToken();
        const questionsResponse = await fetch('api/questions', {
            headers: !token ? {} : { 'Authorization': `Bearer ${token}` }
        });
        const questionsData = await questionsResponse.json();
        const answersResponse = await fetch('api/answers/', {
            headers: !token ? {} : { 'Authorization': `Bearer ${token}` }
        });
        const answersData = await answersResponse.json();
        const user = await authService.getUser();
        this.setState({
            questions: questionsData,
            answers: answersData,
            answerOptions: answersData.filter(x => x.questionId === questionsData[0].id),
            loading: false,
            userName: user.name
        });
        this.initialState = this.state;
    }
}
export default Quiz;