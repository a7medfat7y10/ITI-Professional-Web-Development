const BlogPost = require('../models/blogPost');

exports.getAllBlogPosts = (req,res, next) => {
    if(!req.session.isLoggedIn){
        return res.redirect('/login');
    }
    BlogPost.find()
    .populate('userId')
    .then(blogPosts => {
        res.render('blogIndex', {
            pageTitle: 'All Blog Posts', 
            Posts : blogPosts,
            isAuthenticated: req.session.isLoggedIn         
        })
    })
}

exports.getAddBlogPost = (req,res,next) => {
    if(!req.session.isLoggedIn){
        return res.redirect('/login');
    }
 res.render('createBlogPost', {
     pageTitle: 'Create new Post',
     isAuthenticated: req.session.isLoggedIn
 })
}

exports.postAddBlogPost = (req,res,next) => {
    if(!req.session.isLoggedIn){
        return res.redirect('/login');
    }
    const blogPostTitle = req.body.blogPostTitle;
    const blogPostBody = req.body.blogPostBody;
    const blogPostDate = Date.now(); 
    const blogPost = new BlogPost({
        blogPostBody: blogPostBody, 
        blogPostDate: blogPostDate, 
        blogPostTitle: blogPostTitle,
        userId: req.user
     });
    blogPost.save()
    .then(result => {
        console.log('Post created');
        res.redirect('/');
    })
    .catch(err => {
        console.log(err);
    })
} 

exports.getEditBlogPost = (req, res, next) => {
    if(!req.session.isLoggedIn){
        return res.redirect('/login');
    }
    const blogPostId = req.params.blogPostId;
    BlogPost.findById(blogPostId)
    .then(post => {
        if(!post) {
            return res.redirect('/');
        }
        res.render('editBlogPost', {
            pageTitle: 'Edit Post',
            post: post,
            isAuthenticated: req.session.isLoggedIn
        })
    })
    .catch(err => console.log(err));
}

exports.postEditBlogPost = (req,res,next) => {
    const blogPostId = req.body.blogPostId;
    const updatedPostTitle = req.body.blogPostTitle;
    const updatedPostBody = req.body.blogPostBody;
    const updatedPostDate = Date.now();
    console.log(blogPostId);

    BlogPost.findById(blogPostId)
    .then(post => {
        post.blogPostTitle = updatedPostTitle;
        post.blogPostBody = updatedPostBody;
        post.blogPostDate = updatedPostDate;
        return post.save();
    })   
    .then(result => {
        console.log('Post Updated');
        res.redirect('/');
    })
    .catch(err => {
        console.log(err);
    })
} 

exports.postDeleteBlogPost = (req,res, next) => {
    const blogPostId = req.body.blogPostId;
    BlogPost.findByIdAndRemove(blogPostId)
    .then(() => {
        console.log('Post removed');
        res.redirect('/posts');
    })
    .catch(err => console.log(err));
}