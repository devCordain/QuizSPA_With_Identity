import React, { Component } from 'react';

export class Home extends Component {
  static displayName = Home.name;

  render () {
    return (
      <div>
            <h2>Welcome to the Quiz App!</h2>
            <p> Create an account to start quizzing, or check out the current highscore standings before getting started! </p>
      </div>
    );
  }
}
