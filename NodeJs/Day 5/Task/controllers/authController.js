const User = require('../models/user');

exports.getLogin = (req, res, next) => {
  res.render('auth/login', {
    path: '/login',
    pageTitle: 'Login',
    isAuthenticated: false
  });
};

exports.getSignup = (req, res, next) => {
  res.render('auth/signup', {
    path: '/signup',
    pageTitle: 'Signup',
    isAuthenticated: false
  });
};

exports.postLogin = (req, res, next) => {
  const email = req.body.email;
  const password = req.body.password;
  User.findOne({email : email})
  .then(user => {
    if(!user){
        return res.redirect('/login');
    }
    if(password != user.password){
        return res.redirect('/login');
    }
    req.session.isLoggedIn = true;
    req.session.user = user;
    return req.session.save(err => {
        console.log(err);
        res.redirect('/');
    })
  })
};

exports.postSignup = (req, res, next) => {
    const email = req.body.email;
    const password = req.body.password;
    const confirmPassword = req.body.confirmPassword;

    User.findOne({email : email})
    .then(userExist => {
        if (userExist){
            return res.redirect('/signup');
        }
        const user = new User({
            email : email,
            password : password,
            posts: []
        });
        return user.save();
    })
    .then(result => {
        res.redirect('/login')
    })
    .catch(err => console.log(err));
};

exports.postLogout = (req, res, next) => {
  req.session.destroy(err => {
    console.log(err);
    res.redirect('/');
  });
};
