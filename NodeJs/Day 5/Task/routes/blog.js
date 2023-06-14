const path = require('path');

const express = require('express');

const postController = require('../controllers/postController');

const router = express.Router();

router.get('/', postController.getAllBlogPosts);
router.get('/posts', postController.getAllBlogPosts);

router.get('/newpost', postController.getAddBlogPost);

router.post('/newpost', postController.postAddBlogPost);

router.get('/editpost/:blogPostId', postController.getEditBlogPost);

router.post('/editpost/:blogPostId', postController.postEditBlogPost);

router.post('/deletepost', postController.postDeleteBlogPost);

// router.get('/', shopController.getIndex);

// router.get('/products', shopController.getProducts);

// router.get('/products/:productId', shopController.getProductById);

// router.get('/cart', shopController.getCart);

// router.post('/cart');

// router.get('/orders', shopController.getOrders);

// router.get('/checkout', shopController.getCheckout);

module.exports = router;
