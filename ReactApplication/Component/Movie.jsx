import React, { component } from 'react'
import axios from 'axios'
export class Movies extends React.Component {

    constructor(props) {
        super(props);

        this.state = {
            movies: [],
            loading: false
        }
    }


    componentDidMount() {
        this.populateMoviesdata();
    }

    populateMoviesdata() {
        axios.get("api/Movies/GetMovies").then(result => {
            const response = result.data;
            this.setState({ movies: response, loading: false });
        });
    }

    renderAllmoviesTable(movies) {
        return (
            <table className="table table-stripped">
                <thead>
                    <tr>
                        <th>ID</th>
                        <th>Title</th>
                        <th>Year</th>
                        <th>Rating</th>
                        <th>Franchise</th>
                    </tr>
                </thead>
                <tbody>
                    {movies.map(movie => {
                        <tr key={movie.id}>
                            <td>movie.ID</td>
                            <td>movie.Title</td>
                            <td>movie.Year</td>
                            <td>movie.Franchise</td>
                            <td>movie.Rating</td>
                        </tr>

                    })}


                </tbody>
            </table>
        );
    }

    render() {
        let content = this.state.loading ? (<p>Loading...</p>) : (
            this.renderAllmoviesTable(this.state.movies)
        )


        return (
            <div>
                <h1>All Movies</h1>
                <p> Here you can see all movies list</p>
                {content}
            </div>
        );
    }
}