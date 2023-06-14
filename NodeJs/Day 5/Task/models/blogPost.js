const mongoose = require('mongoose');

const Schema = mongoose.Schema;

const blogPostSchema = new Schema({
    blogPostTitle: {
        type:String,
        required:true
    },
    blogPostBody: {
        type: String,
        required: true
    },
    blogPostDate: {
        type: Date,
        required: true
    },
    userId: {
        type: Schema.Types.ObjectId,
        ref: 'User',
        required: true
    }
})

module.exports = mongoose.model('BlogPost', blogPostSchema);
