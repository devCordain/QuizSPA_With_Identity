import React, { Component } from 'react';

export class HighScores extends Component {
  static displayName = HighScores.name;

  constructor(props) {
    super(props);
    this.state = { highScores: [], loading: true };
  }

  componentDidMount() {
    this.populateHighScoreData();
  }

  static renderHighScoreTable(highScores) {
    return (
      <table className='table table-striped' aria-labelledby="tabelLabel">
        <thead>
          <tr>
            <th>Name</th>
            <th>Score</th>
          </tr>
        </thead>
        <tbody>
          {highScores.map(highScore =>
            <tr key={highScore.id}>
              <td>{highScore.userName}</td>
              <td>{highScore.score}</td>
            </tr>
          )}
        </tbody>
      </table>
    );
  }

  render() {
    let contents = this.state.loading
      ? <p><em>Loading...</em></p>
      : HighScores.renderHighScoreTable(this.state.highScores);

    return (
      <div>
        <h1 id="tabelLabel" >HighScores</h1>
        <p>Check out how your score competes against the masters</p>
        {contents}
      </div>
    );
  }

  async populateHighScoreData() {
    const response = await fetch('api/highscores/', {});
    const data = await response.json();
    this.setState({ highScores: data, loading: false });
  }
}
