#include "sys.h"
#include "delay.h"
#include "usart.h"
#include "led.h"
#include "myiic.h"
#include "bme280.h"

int main(void)
{
	float bmp280_temp;
	float bmp280_press;
	float bmp280_humi;
	float high;
	NVIC_PriorityGroupConfig(NVIC_PriorityGroup_2);                            //�����ж����ȼ�����2
	uart_init(115200);                                                           //��ʼ��USART
	LED_Init();                                                                //��ʼ��LED
  IIC_Init();	
	delay_init(168);
	bme280Init();
    while(1)
    {
      bme280GetData(&bmp280_press,&bmp280_temp,&bmp280_humi,&high);
			delay_ms(100);
			LED0=!LED0;
			
			printf("%fE%fE",bmp280_humi,bmp280_temp);
			
	}
}
