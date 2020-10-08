import { getJson, postJson, deleteJson } from './baseApi.js'

export function getAllTweetsByUser ({ userId }) {
  return getJson({
    url: 'https://localhost:44331/api/tweets/' + userId + '/getTweets'
  })
}
export function getAllTweets () {
  return getJson({
    url: 'https://localhost:44331/api/tweets'
  })
}

export function getTweet ({ tweetId }) {
  return getJson({
    url: 'https://localhost:44331/api/tweets/' + tweetId
  })
}

export function deleteTweet ({ tweetId }) {
  return deleteJson({
    url: 'https://localhost:44331/api/tweets/' + tweetId
  })
}

export function postTweet ({ userId, message }) {
  return postJson({
    url: 'https://localhost:44331/api/tweets',
    data: {
      userId: userId,
      message: message
    }
  })
}

