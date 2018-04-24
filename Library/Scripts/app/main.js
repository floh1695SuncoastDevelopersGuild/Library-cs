/**
 * Library interface application
 */

const app = angular.module('libraryApp', []);

app.controller('libraryController',
    ['$scope', '$http', ($scope, $http) => {
        console.group('libraryController');

        // NOTE: results is what is shown on the screen
        $scope.results = [];

        $scope.search = { title: '', genre: '', author: '', checkedOut: false };

        $scope.setBooks = books => {
            console.group('setBooks');

            let newBooks = [];
            books.forEach(book => {
                let newBook = {
                    id: book.ID,
                    title: book.BookData.Title,
                    genre: book.BookData.Genre.Name,
                    author: book.BookData.Author.Name,
                    isCheckedOut: book.IsCheckedOut,
                };
                console.log(newBook);
                newBooks.push(newBook);
                $scope.results = newBooks;
            });

            console.groupEnd();
            $scope.books = newBooks;
        };

        // TODO: Need a refactoring, bad
        $scope.searchBooks = () => {
            const options = [];
            const search = JSON.parse(JSON.stringify($scope.search)); // Lazy deep clone
            search.checkedOut = !search.checkedOut;
            Object.entries(search).forEach(entry => {
                const key = entry[0];
                const value = entry[1];
                if (typeof value === 'boolean' && !value) {
                    options.push(entry.join('='));
                }
                else if (typeof value === 'string' && value.length) {
                    options.push(entry.join('='));
                }
                
            });
            let url = '/api/search?' + options.join('&');

            $http({
                method: 'GET',
                url: url
            }).then(response => {
                $scope.setBooks(response.data);
            });
        };

        $scope.toggleCheckedOut = book => {
            $http({
                method: 'POST',
                url: `/api/checking/${book.isCheckedOut ? 'in' : 'out'}?id=${book.id}`
            }).then(result => {
                book.isCheckedOut = !book.isCheckedOut;
                console.log(result.status);
            });
        };

        $scope.availabilityMessage = book => {
            return book.isCheckedOut ? 'Check in' : 'Check out';
        };

        console.groupEnd();
    }]);
