# News Platform

This is an ASP .Net MVC application which allows browsing articles related to sport.
Features:
- The homepage has an animation created in JavaScript.
- There are three access levels - administrator, privileged user, regular user.
- The Administrator can add and delete articles, add comments, and change the application background.
- The Privileged User can add comments and change the background.
- The Regular User can only add comments.
- Every user can list all the articles and read each of them.
- Each time a user logs in, he/she receives an additional point, after receiving 10 points, they become a privileged user.
- After registration a user gains an additional one point, at the beginning he/she has zero points.
- The project includes 2 unit tests, one checks the admin login, and the other verifies the return value of one of the controllers.
- The system allows both registering new users and logging in existing users.
- Articles can be added in 3 different ways - through code (one article), system interface, and SQL command in the database.
- All data is stored in a Microsoft SQL Express database, tables: Users, Articles, Logs, Comments.
- The system automatically creates logs (notes) upon login and logout, including information about successful or unsuccessful actions.