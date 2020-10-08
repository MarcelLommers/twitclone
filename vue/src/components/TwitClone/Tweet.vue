<template>
	<div
		class="tweet"
	>
		<div
			class="tweet-header"
		>
			<label
				class="header-user-link"
				v-text="targetUser.userName"
				@click="goToUser"
			>
			</label>
			<label
				class="header-user-email"
				v-text="targetUser.email"
				@click="deleteTweet">
			</label>
			<span
				class="post-date"
				v-text="postDate"
			>
			</span>


		</div>

		<div
			class="tweet-content"
		>
		<span
			class="content-message"
			v-text="messageContent"
		>
		</span>

		<div
			class="video-container"
			v-if="videoLink"
			v-html="videoLink"
		>
		</div>
		</div>
	</div>
</template>

<script>
	import _ from 'lodash'

	export default {
		name: "TwitClonePage",
		props: {
			tweetData: {
				default: function () {
					return {}
				},
				type: Object
			},
			userList: {
				default: function () {
					return []
				},
				type: Array
			}
		},
		data () {
			return {
			}
		},
		computed: {
			targetUser () {
				let result = _.find(this.userList, {'userId': this.tweetData.userId })

				return result || { userName: '' }
			},
			postDate () {
				return new Date(this.tweetData.postDate).toLocaleString();
			},
			containsIFrame () {
				return this.tweetData.message.includes('<iframe');
			},
			iFrameIndex () {
				return this.tweetData.message.indexOf('<iframe');
			},
			messageContent () {
				if (this.containsIFrame) {
					return this.tweetData.message.substring(0, this.iFrameIndex)
				} else {
					return this.tweetData.message
				}
			},
			videoLink () {
				if (this.containsIFrame) {
					return this.tweetData.message.substring(this.iFrameIndex, this.tweetData.message.length)
				}
				return null
			}
		},
		methods: {
			goToUser () {
				if (!this.$route.path.includes(this.tweetData.userId)) {
					this.$router.push({
						name: 'twitCloneUser',
						params: {
							userId: this.tweetData.userId
						}
					})
				}
			},
			deleteTweet () {
				this.$emit('delete', { 'tweetId': this.tweetData.id})
			}
		}
	}
</script>

<style lang="scss" scoped>

	.tweet {
		border: 1px solid #58585b;
		border-radius: 5px;
		min-height: 80px;
		margin: 5px 5px 20px 5px;
		text-align: left;
		overflow: hidden;

		-webkit-box-shadow: 3px 2px 22px -4px rgba(0,0,0,0.75);
		-moz-box-shadow: 3px 2px 22px -4px rgba(0,0,0,0.75);
		box-shadow: 3px 2px 22px -4px rgba(0,0,0,0.75);

		.tweet-header {
			display: flex;
			background-color: #00bbd5;
			color: white;
			padding: 2px 10px;
			height: 25px;
			align-items: center;
			justify-content: space-between;

			.header-user-link {
				cursor: pointer;
				font-size: 18px;

				&:hover {
					color: #eeeeee;
				}
			}

			.header-user-email {
				flex: 1 1;
				text-indent: 10px;
				text-align: left;
				font-size: 13px;
			}

			.post-date {
				text-align: right;
				width: 140px;
				font-size: 13px;
			}
		}

		.tweet-content {
			display: block;
			font-size: 13px;
			flex: 1 1;
			padding: 10px 15px 20px;
			overflow-y: auto;

			.content-message {
				margin-bottom: 10px;
			}

			.video-container {
				padding-top: 10px;

				.video {
					width: 100%;
				}
			}
		}
	}

</style>