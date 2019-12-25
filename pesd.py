import time
from selenium.webdriver.common.keys import Keys
from selenium import webdriver
from selenium.webdriver.support.wait import WebDriverWait
from time import sleep

#   打开浏览器
#   返回webdriver实例
def open_web_browser():
    _dr = webdriver.Chrome()
    _dr.implicitly_wait(20)
    return _dr

#   打开视频地址
#   例："https://www.bilibili.com/video/av79362092"
def open_video_page(_dr, _video_page_url):
    _dr.get(_video_page_url)
    sleep(2) #稍微等待一下缓冲

#   等待登录
#   最长超时2分钟，将在服务器端关闭
def open_login_page_and_wait_log_in(_dr):
    _dr.get("https://passport.bilibili.com/login")
    WebDriverWait(_dr,120).until(lambda d: d.title == ("哔哩哔哩 (゜-゜)つロ 干杯~-bilibili")) # 这一步完成后将开始等待所有人登录准备就绪

#   将视频定位至location
#   例：locate_at(_dr,"10")
#   例：locate_at(_dr,"3:00")
def locate_at(_dr, _location):
    find_specificated_element_by_xpath(_dr,"//*[@id=\"bilibiliPlayer\"]/div[1]/div[1]/div[10]/div[2]/div[2]/div[1]/div[2]/div/span[1]").click()
    _elm = find_specificated_element_by_xpath(_dr, "//*[@id=\"bilibiliPlayer\"]/div[1]/div[1]/div[10]/div[2]/div[2]/div[1]/div[2]/input")
    _elm.send_keys(Keys.CONTROL + 'a')
    _elm.send_keys(Keys.BACKSPACE)
    _elm.send_keys(_location)
    _elm.send_keys(Keys.ENTER)

#   返回当前视频的时间
#   例："3:14"
def get_current_location_text(_dr):
    return find_specificated_element_by_xpath(_dr, "//*[@id=\"bilibiliPlayer\"]/div[1]/div[1]/div[10]/div[2]/div[2]/div[1]/div[2]/div/span[1]").text

def find_specificated_element_by_xpath(_dr, _xpath_string):
    return WebDriverWait(_dr,30).until(lambda d: d.find_elements_by_xpath(_xpath_string))[0]

if __name__ == "__main__":
    _dr = open_web_browser()

    open_login_page_and_wait_log_in(_dr)
    # 向服务器发出准备就绪的通知
    open_video_page(_dr,"https://www.bilibili.com/video/av79362092")
    # 轮询检查是否同步
    # 查看服务器发来的通知，是否需要同步
    locate_at(_dr,"10")
        

